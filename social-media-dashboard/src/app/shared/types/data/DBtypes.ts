import { metricType, platformType } from "../StringLiterals"

export type ClientType = {
  id: number,
  name: string,
  datasets: PlatformDatasetType[]
}

export type PlatformDatasetType = {
  id: number,
  clientId: number,
  platform: platformType,
  metrics: PlatformMetricType[]
}

export type PlatformMetricType = {
  id: number,
  platformDatasetId: number,
  metric: metricType,
  startDate: Date,
  target: number,
  progress: MetricProgressType[]
}

export type MetricProgressType = {
  id: number,
  platformMetricId: number,
  day: number,
  currentValue: number
}

