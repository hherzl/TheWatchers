import { Routes } from '@angular/router';
import { Home } from '../home/home';
import { WatchersListComponent } from '../watchers-list/watchers-list.component';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'watchers', component: WatchersListComponent }
];
