import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { HttpClientModule, HTTP_INTERCEPTORS,provideHttpClient, withFetch } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

import { routes } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }) ,importProvidersFrom(BrowserModule, RouterModule), provideHttpClient(withFetch()) , provideRouter(routes), provideClientHydration(withEventReplay())]
};
