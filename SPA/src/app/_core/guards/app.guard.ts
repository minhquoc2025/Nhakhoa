import { Injectable, inject } from '@angular/core';
import { CanMatchFn, Route, Router } from '@angular/router';
import { LocalStorageConstants } from "@constants/local-storage.constants";
import { DirectoryInfomation, FunctionInfomation, ProgramInfomation, UserForLogged } from "@models/auth/auth";
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from '@services/auth/auth.service';
import { NgSnotifyService } from '@services/ng-snotify.service';

@Injectable({
  providedIn: 'root'
})
export class AppGuard {
  private resetDirId: string = '2'
  private resetPassAddr: string = `${this.resetDirId}.1.8`
  private recentProgram: string = ''
  constructor(
    private router: Router,
    private snotify: NgSnotifyService,
    private translate: TranslateService,
    private authService: AuthService
  ) { }
  async canMatchMain(route: Route): Promise<boolean> {
    try {
      this.recentProgram = route.data['program'];
      const user: UserForLogged = JSON.parse(localStorage.getItem(LocalStorageConstants.USER) || '{}');
      const directoryUser: DirectoryInfomation[] = user?.directories || [];
      const programUser: ProgramInfomation[] = user?.programs || [];
      if (!user || directoryUser.length == 0 || programUser.length == 0 || !this.authService.loggedIn())
        return this.next(false, '/login');
      const hasProgramAccess = programUser.some(x => x.program_Code?.trim() === this.recentProgram?.trim());
      if (!hasProgramAccess)
        return this.next(false, '/dashboard');
      const passwordReset = await this.authService.getPasswordReset(user.account);
      if (passwordReset && this.recentProgram !== this.resetPassAddr) {
        const directoryUrl = directoryUser.find(x => x.seq == this.resetDirId)?.directory_Name?.toUrl() || ''
        const programUrl = programUser.find(x => x.program_Code === this.resetPassAddr)?.program_Name?.toUrl() || ''
        if (directoryUrl.isNullOrWhiteSpace() || programUrl.isNullOrWhiteSpace())
          return this.next(false, "/500")
        const resetPasswordUrl = `/${directoryUrl}/${programUrl}`;
        this.snotify.clear();
        this.snotify.warning(
          this.translate.instant('System.Message.PasswordReset'),
          this.translate.instant('System.Caption.Warning')
        );
        return this.next(false, resetPasswordUrl);
      }
      return this.next(true);
    } catch {
      return this.next(false, '/500');
    }
  }
  canMatchForm(route: Route): boolean {
    const user: UserForLogged = JSON.parse(localStorage.getItem(LocalStorageConstants.USER) || '{}');
    const functions: FunctionInfomation[] = user?.functions || [];
    const functionUser = functions.filter(val => val.program_Code == this.recentProgram)
    const isExisted = functionUser.some(x => x.function_Code == route.data.title)
    return this.next(isExisted, !isExisted ? this.router.url : null)
  }
  private next(result: boolean, url?: string) {
    if (!result) url == '/login' ? this.authService.logout() : this.router.navigate([url]);
    return result;
  }
}
export const appGuard: CanMatchFn = (route: Route) => {
  return inject(AppGuard).canMatchMain(route);
};
export const formGuard: CanMatchFn = (route: Route) => {
  return inject(AppGuard).canMatchForm(route);
};
