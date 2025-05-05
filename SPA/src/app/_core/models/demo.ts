import { BaseSource } from "./base-source";

export interface Demo {
  id: number;
  title: string;
}

export interface DemoFilter {
  keyword: string;
}

export interface Demo_Source extends BaseSource<Demo> {
  filter: DemoFilter;
}