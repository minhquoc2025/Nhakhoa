import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { environment } from '@env/environment';
import { Demo, Demo_Source, DemoFilter } from '@models/demo';
import { OperationResult } from '@utilities/operation-result';
import { Pagination, PaginationResult } from '@utilities/pagination-utility';
import { Observable } from 'rxjs';
import { toObservable } from '@angular/core/rxjs-interop';

@Injectable({
  providedIn: 'root'
})
export class DemoService {
  baseUrl = `${environment.apiUrl}Demo`;
  initData: Demo_Source = <Demo_Source>{
    model: <Demo>{},
    data: [],
    filter: <DemoFilter>{},
    pagination: <Pagination>{ pageNumber: 1, pageSize: 10, totalCount: 0 }
  }

  basicCodeSource = signal<Demo_Source>(structuredClone(this.initData));
  source = toObservable(this.basicCodeSource);
  setSource = (source: Demo_Source) => this.basicCodeSource.set(source);
  clearParams = () => {
    this.basicCodeSource.set(structuredClone(this.initData))
  }

  constructor(private _http: HttpClient) { }

  getDataMainPagination(param: Pagination, filter: DemoFilter): Observable<PaginationResult<Demo>> {
    let params = new HttpParams().appendAll({ ...param, ...filter });
    return this._http.get<PaginationResult<Demo>>(`${this.baseUrl}/GetDataPagination`, { params });
  }

  create(model: Demo) {
    return this._http.post<OperationResult>(`${this.baseUrl}/Create`, model);
  }

  update(model: Demo) {
    return this._http.put<OperationResult>(`${this.baseUrl}/Update`, model);
  }


  delete(id: number) {
    return this._http.delete<OperationResult>(`${this.baseUrl}/Delete`, { params: { id } });
  }

  download(filter: DemoFilter) {
    let params = new HttpParams().appendAll({ ...filter });
    return this._http.get<OperationResult>(`${this.baseUrl}/Export`, { params });
  }
}
