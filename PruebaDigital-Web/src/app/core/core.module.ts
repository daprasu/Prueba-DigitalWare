import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule, Optional, SkipSelf } from '@angular/core';

// Component
// import { AlertService } from 'app/core/services/alert.service';

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule
    ],
    // providers: [
    //     AlertService
    // ],
    entryComponents: []
})
export class CoreModule {
    constructor(@Optional() @SkipSelf() core: CoreModule) {
        if (core) {
            throw new Error('El servicio no esta corriendo!');
        }
    }
}