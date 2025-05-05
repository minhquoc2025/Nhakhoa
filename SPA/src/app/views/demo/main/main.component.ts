import { Component, effect, OnInit } from '@angular/core';
import { IconButton } from '@constants/common.constants';
import { Demo, Demo_Source, DemoFilter } from '@models/demo';
import { DemoService } from '@services/demo.service';
import { InjectBase } from '@utilities/inject-base-app';
import { Pagination } from '@utilities/pagination-utility';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent extends InjectBase implements OnInit {
  //#region Data
  demo: Demo[] = [];

  //#endregion

  //#region Vaiables
  filter: DemoFilter = <DemoFilter>{
    keyword: ''
  }
  selectedData: Demo = <Demo>{}
  title: string = 'Demo';
  iconButton = IconButton;
  //#endregion

  //#region Pagination
  pagination: Pagination = <Pagination>{
    pageNumber: 1,
    pageSize: 10,
    totalCount: 0
  }
  //#endregion

  constructor(
    private _services: DemoService,
  ) {
    super();

    // Load danh sách Data trước đó
    effect(() => {
      // 0. Gán params & pagination
      this.filter = this._services.basicCodeSource().filter;
      this.pagination = this._services.basicCodeSource().pagination;
      this.demo = this._services.basicCodeSource().data;
    });

    // Load lại dữ liệu khi thay đổi ngôn ngữ
    // this.translateService.onLangChange.pipe(takeUntilDestroyed()).subscribe(() => {
    //   this.title = this.functionUtility.getTitle(this.route.snapshot.data['program'])
    // });
  }
  ngOnDestroy(): void {
    this._services.setSource(<Demo_Source>{
      pagination: this.pagination,
      filter: this.filter,
      data: this.demo,
      model: this.selectedData
    });
  }

  ngOnInit(): void {
    this.title = 'Demo'
  }

  //#region Methods
  getPaginationData(isSearch?: boolean) {
    this.spinnerService.show();
    this._services.getDataMainPagination(this.pagination, this.filter).subscribe({
      next: result => {
        this.spinnerService.hide();
        this.demo = result.result;
        this.pagination = result.pagination;
        if (isSearch)
          this.functionUtility.snotifySuccessError(true, 'System.Message.QuerySuccess')
      },
      error: () => this.functionUtility.snotifySystemError()
    })
  }

  search = (isSearch: boolean) => this.pagination.pageNumber === 1 ? this.getPaginationData(isSearch) : this.pagination.pageNumber = 1;

  deleteProperty = (name: string) => delete this.filter[name]

  clear() {
    this.filter = <DemoFilter>{}
    this.pagination.pageNumber = 1;
    this.pagination.totalCount = 0;
    this.demo = [];
  }

  pageChanged(event: any) {
    this.pagination.pageNumber = event.page;
    this.getPaginationData();
  }
  //#endregion

  //#region Events
  onAdd() {
    this.router.navigate([`${this.router.routerState.snapshot.url}/add`]);
  }

  onEdit(item: Demo) {
    this.selectedData = item;
    this.router.navigate([`${this.router.routerState.snapshot.url}/edit`]);
  }

  onDetail(item: Demo) {
    this.selectedData = item;
    this.router.navigate([`${this.router.routerState.snapshot.url}/detail`]);
  }

  onDelete(id: number) {
    this.functionUtility.snotifyConfirmDefault(() => {
      this.spinnerService.show();
      this._services.delete(id).subscribe({
        next: result => {
          this.spinnerService.hide();
          this.functionUtility.snotifySuccessError(result.isSuccess, result.isSuccess ? `System.Message.DeleteOKMsg` : result.error, result.isSuccess)
          if (result.isSuccess) this.search(false);
        },
        error: () => this.functionUtility.snotifySystemError()
      })
    });
  }

  onExport() {
    this.spinnerService.show();
    this._services.download(this.filter).subscribe({
      next: (result) => {
        this.spinnerService.hide();
        const fileName = this.functionUtility.getFileName('Demo_Download')
        this.functionUtility.exportExcel(result.data, fileName);
      },
      error: () => this.functionUtility.snotifySystemError()
    });
  }
  //#endregion

}
