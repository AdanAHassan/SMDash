import { DataCardType } from "./DataCardType"
import { metricType } from "./StringLiterals"

export type TableDataType = {
  index: number,
  timespan: TimeSpanTypes,
  values: MetricTableType[]
}

export type MetricTableType = {
  metric: metricType,
  value: number
}

export type TimeSpanTypes = "day" | "week" | "month" | "quarter"
