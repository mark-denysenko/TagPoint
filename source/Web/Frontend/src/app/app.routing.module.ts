import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppRouteGuard } from "./core/guards/route.guard";
import { AppLayoutMainComponent } from "./layouts/layout-main/layout-main.component";
import { AppLayoutComponent } from "./layouts/layout/layout.component";

const routes: Routes = [
    {
        path: "",
        component: AppLayoutComponent,
        children: [
            {
                path: "login",
                loadChildren: () => import("./views/login/login.module").then((x) => x.AppLoginModule)
            },
            {
                path: "register",
                loadChildren: () => import("./views/register/register.module").then((x) => x.AppRegisterModule)
            },
            { path: "", redirectTo: "login", pathMatch: 'full' }
        ]
    },
    {
        path: "main",
        component: AppLayoutMainComponent,
        canActivate: [AppRouteGuard],
        children: [
            {
                path: "home",
                loadChildren: () => import("./views/main/home/home.module").then((x) => x.AppHomeModule)
            },
            {
                path: "list",
                loadChildren: () => import("./views/main/list/list.module").then((x) => x.AppListModule)
            },
            {
                path: "profile",
                loadChildren: () => import("./views/profile/profile.module").then((x) => x.ProfileModule)
            },
            {
                path: "map",
                loadChildren: () => import("./views/main-page/main-page.module").then((x) => x.MainPageModule)
            }
        ]
    },
    { path: "**", redirectTo: "main/map" }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
