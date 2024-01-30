import { ChartConfiguration, ChartOptions, ChartType } from "chart.js";
import { ProgressDataType } from "./ProgressDataType";
import { TableDataType } from "./TableCardType";

export type genericCardType = defaultChart | loadingChart | progressChart | tableChart

interface genericCardInnerType {
  option? : ChartOptions,
  legends? : boolean,
  type: string,
  data: any
}

// For chart.js
export interface defaultChart extends genericCardInnerType {
  type: ChartType,
  data: ChartConfiguration["data"]
}

// Null type
interface loadingChart extends genericCardInnerType {
  type: "loading",
  data: []
}

// Add types for new charts below
interface progressChart extends genericCardInnerType {
  type: "progress",
  data: ProgressDataType[] | []
}

interface tableChart extends genericCardInnerType {
  type: "table",
  data: TableDataType[] | []
}
