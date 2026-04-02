import { Routes } from '@angular/router';
import { Home } from '../home/home';
import { WatcherList } from '../watcher-list/watcher-list';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'watchers', component: WatcherList }
];
