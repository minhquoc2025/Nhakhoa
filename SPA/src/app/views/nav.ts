import { Injectable } from '@angular/core';
import { INavData } from '@coreui/angular';
@Injectable({ providedIn: 'root' })
export class Nav {
    navItems: INavData[] = [];
    constructor() { }
    getNav() {
        return this.navItems = [
            {
                name: 'Home',
                icon: 'cil-home',
                url: '/home',
                attributes: { class: 'text-uppercase font-weight-bold' },
                children: [
                    {
                        name: 'Demo',
                        url: '/dashboard',
                        icon: 'cil-settings'
                    },
                    {
                        name: 'Profile',
                        url: '/demo',
                        icon: 'cil-home'
                    }
                ]
            }
        ];
    }

}

