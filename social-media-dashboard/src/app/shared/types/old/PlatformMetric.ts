import { metricType } from "../StringLiterals"

export type platformMetric = {
  metric: metricType,
  target: number,
  progress: number[],
  startDate: Date
}

// Can calculate graph data with a startDate and index values of progress
