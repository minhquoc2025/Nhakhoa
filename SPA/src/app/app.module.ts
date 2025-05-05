;
import { APP_INITIALIZER, CUSTOM_ELEMENTS_SCHEMA, importProvidersFrom, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { DefaultLayoutComponent } from './containers/default-layout/default-layout.component';

import { Page404Component } from '@views/error/page-404/page-404.component';
import { Page500Component } from '@views/error/page-500/page-500.component';

// Import containers
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const APP_CONTAINERS = [
  DefaultLayoutComponent,
  Page404Component,
  Page500Component
];

import {
  AppAsideModule,
  AppBreadcrumbModule,
  AppFooterModule,
  AppHeaderModule,
  AppSidebarModule,
} from '@coreui/angular';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';


import { NgProgressModule } from "ngx-progressbar";
import { NgProgressHttpModule } from 'ngx-progressbar/http';


import { NgSelectModule } from '@ng-select/ng-select';
import { NgxSpinnerModule } from 'ngx-spinner';

import { IConfig, NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { SnotifyModule, SnotifyService, ToastDefaults } from 'ng-alt-snotify';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { GlobalHttpInterceptor } from '@utilities/global-http-interceptor';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';

const maskConfig: Partial<IConfig> = {
  validation: false,
};

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    ...APP_CONTAINERS
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    RouterModule,

    // CoreUI modules
    AppAsideModule,
    AppBreadcrumbModule,
    AppFooterModule,
    AppHeaderModule,
    AppSidebarModule,

    SnotifyModule,

    NgSelectModule,
    NgxSpinnerModule,

    NgxMaskDirective,
    NgxMaskPipe,


    NgProgressModule.withConfig({ spinner: false }),
    NgProgressHttpModule,

    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: HashLocationStrategy
    },
    { provide: 'SnotifyToastConfig', useValue: ToastDefaults },
    { provide: HTTP_INTERCEPTORS, useClass: GlobalHttpInterceptor, multi: true },

    SnotifyService,
    provideNgxMask(maskConfig),
    importProvidersFrom(NgProgressHttpModule),
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
