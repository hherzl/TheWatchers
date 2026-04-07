import { Routes } from '@angular/router';
import { Home } from '../home/home';
import { WatchersListComponent } from '../watchers-list/watchers-list.component';
import { WatcherDetailsComponent } from '../watcher-details/watcher-details.component';
import { ResourcesListComponent } from '../resources-list/resources-list.component';
import { ResourceDetails } from '../resource-details/resource-details';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'watchers', component: WatchersListComponent },
    { path: 'watchers/:id', component: WatcherDetailsComponent },
    { path: 'resources', component: ResourcesListComponent },
    { path: 'resources/:id', component: ResourceDetails }
];
