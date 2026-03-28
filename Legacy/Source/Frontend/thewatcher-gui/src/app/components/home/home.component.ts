import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import * as signalR from '@aspnet/signalr';
import { MonitorClientService, ResourceWatchItemModel } from 'src/app/services/monitor-client.service';
import { ListResponse } from 'src/app/services/common';
import { MONITOR_API_ENDPOINT } from 'src/settings';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  /** Based on the screen size, switch from standard to one column per row */
  cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return [
          { title: 'Card 1', cols: 1, rows: 1 },
          { title: 'Card 2', cols: 1, rows: 1 },
          { title: 'Card 3', cols: 1, rows: 1 },
          { title: 'Card 4', cols: 1, rows: 1 }
        ];
      }

      return [
        { title: 'Card 1', cols: 2, rows: 1 },
        { title: 'Card 2', cols: 1, rows: 1 },
        { title: 'Card 3', cols: 1, rows: 2 },
        { title: 'Card 4', cols: 1, rows: 1 }
      ];
    })
  );

  private hubEndpoint!: string;

  constructor(private breakpointObserver: BreakpointObserver, private monitorClient: MonitorClientService) {
    this.hubEndpoint = `${MONITOR_API_ENDPOINT}/monitorhub`;
  }

  private hubConnection!: signalR.HubConnection;
  public response!: ListResponse<ResourceWatchItemModel>;

  ngOnInit(): void {

    this.monitorClient.getMonitor().subscribe(result => {
      this.response = result;
    });

    this.hubConnection = new signalR
      .HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Debug)
      .withUrl(this.hubEndpoint)
      .build()
      ;

    this
      .hubConnection
      .start()
      .then(() => {
        console.log('Connection started!');
      })
      .catch(err => console.log(`Error while starting connection: ${err}`))
      ;

    this.hubConnection.on('receiveResourceWatch', (notification: ResourceWatchArg) => {
      console.log(notification);

      this.response.model.forEach((item) => {
        if (item.resourceId == notification.resourceId && item.environmentId == notification.environmentId) {
          item.successful = notification.isSuccess;
          item.watchCount += 1;
        }
      });
    });
  }
}

class ResourceWatchArg {
  public resource!: string;
  public resourceId!: number;
  public environmentId!: number;
  public environment!: string;
  public isSuccess!: boolean;
}
