import { metricType, platformType } from "../StringLiterals"

export type ClientRenderType = {
  id: number,
  name: string,
  platforms: platformType[]
}

export type PlatformDatasetRenderType = {
  id: number,
  clientId: number,
  platform: platformType,
  metrics: metricType[]
}

export type PlatformMetricRenderType = {
  id: number,
  platformDatasetId: number,
  metric: metricType,
  startDate: Date,
  target: number,
  progress: number[]
}

