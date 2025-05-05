import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { INavData } from '@coreui/angular';
import { Nav } from '@views/nav';
@Component({
  selector: 'app-default-layout',
  templateUrl: './default-layout.component.html',
  styleUrl: './default-layout.component.scss'
})
export class DefaultLayoutComponent  implements OnInit, AfterViewInit {
  @ViewChild('appBody', { static: false }) appBody: ElementRef;
  onScroll = () => this.showScroll = this.appBody.nativeElement.scrollTop > this.showScrollHeight;
  scrollToTop = () => this.appBody.nativeElement.scroll({ top: 0, left: 0, behavior: 'smooth' });
  showScroll: boolean;
  showScrollHeight = 400;

  public sidebarMinimized = false;
  public navItems: INavData[] = [];

  constructor(
    private navItem: Nav
  ) {
    // super()
    this.navItems = this.navItem.getNav();
    // this.translateService.onLangChange.pipe(takeUntilDestroyed()).subscribe(async () => {
    //   this.navItems = this.navItem.getNav();
    // });

    // this.router.events.subscribe((routerEvent: any) => {
    //     if (routerEvent instanceof ResolveStart)
    //       this.spinnerService.show()
    //     if (routerEvent instanceof ResolveEnd)
    //       this.spinnerService.hide()
    //   });
  }
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    window.scrollTo(0, 0);
  }
  checkAccount(account: string[]) {
    // if (account.some(x => this.user.account == x)) {
    //   this.snotifyService.accept(
    //     this.translateService.instant('System.Message.ChangedAccount'),
    //     this.translateService.instant('System.Caption.Warning'),
    //     () => {
    //       this.logout()
    //     });
    // }
  }
  toggleMinimize(e: any) {
    this.sidebarMinimized = e;
  }
  
  logout() {
  }
  ngOnDestroy(): void {
  }
}
function takeUntilDestroyed(): import("rxjs").OperatorFunction<import("@ngx-translate/core").LangChangeEvent, unknown> {
  throw new Error('Function not implemented.');
}

