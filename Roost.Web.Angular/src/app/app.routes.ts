import { Routes } from '@angular/router';
import { AboutComponent } from './pages/about/about.component';
import { BagComponent } from './pages/bag/bag.component';
import { MenuComponent } from './pages/menu/menu.component';
import { RetailComponent } from './pages/retail/retail.component';
import { NotFoundComponent } from './pages/errors/notfound/notfound.component';

export const routes: Routes = [
  { path: 'about', component: AboutComponent, title : "About" },
  { path: 'bag', component: BagComponent, title: "Bag" },
  { path: 'menu', component: MenuComponent, title: "Menu" },
  { path: 'retail', component: RetailComponent, title: "Retail" },
  { path: '', component: MenuComponent, title: "Menu" },
  { path: '**', component: NotFoundComponent, title: "Not Found"}
];
