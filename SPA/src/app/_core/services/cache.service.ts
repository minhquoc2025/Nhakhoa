import { Injectable } from '@angular/core';

export interface IClearCache { clearParams: () => void }
@Injectable({
  providedIn: 'root'
})
export class CacheService {
  constructor(
    // protected service_7_25: S_7_1_25_MonthlySalaryMaintenanceExitedEmployeesService
  ) { }
  clearCache = () => Object.values(this).forEach(x => { if ('clearParams' in x && x['clearParams'] instanceof Function) (x as IClearCache).clearParams() })
}
