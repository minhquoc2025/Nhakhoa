import { Component, OnInit } from '@angular/core';
import '../app/_core/utilities/extension-methods';

import { IconSetService } from '@coreui/icons-angular';
import { freeSet } from '@coreui/icons';

@Component({
  selector: 'body',
  template: `
    <router-outlet></router-outlet>
    <ng-snotify></ng-snotify>
    <ng-progress></ng-progress>
    <ngx-spinner bdColor="rgba(51,51,51,0.8)" size="medium" color="#fff" type="ball-scale-multiple"></ngx-spinner>
  `,
  providers: [IconSetService],
})
export class AppComponent implements OnInit {

  constructor(
    public iconSet: IconSetService
  ) {
    // iconSet singleton
    iconSet.icons = { ...freeSet };
  }
  ngOnInit() {
    // this.translate.addLangs([LangConstants.TW, LangConstants.EN, LangConstants.VN]);
    // let lang: string = localStorage.getItem(LocalStorageConstants.LANG);
    // if (!lang) {
    //   lang = LangConstants.EN
    //   localStorage.setItem(LocalStorageConstants.LANG, lang);
    // }
    // this.translate.setDefaultLang(lang);
    // this.translate.use(lang);
  }
}