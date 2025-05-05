import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Page404Component } from '@views/error/page-404/page-404.component';
import { Page500Component } from '@views/error/page-500/page-500.component';
import { DefaultLayoutComponent } from './containers';

const routes: Routes = [
  {
    path: "",
    redirectTo: "dashboard",
    pathMatch: "full"
  }, {
    path: "404",
    component: Page404Component,
    data: {
      title: "Page 404",
    },
  },
  {
    path: "500",
    component: Page500Component,
    data: {
      title: "Page 500",
    },
  },
  {
    path: "",
    // canActivate: [AuthGuard],
    component: DefaultLayoutComponent,
    data: {
      title: "Home",
    },
    children: [
      {
        path: "dashboard",
        loadChildren: () => import("./views/dashboard/dashboard.module").then((m) => m.DashboardModule),
      },
      {
        path: "demo",
        loadChildren: () => import("./views/demo/demo.module").then((m) => m.DemoModule),
      },
    ]
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
