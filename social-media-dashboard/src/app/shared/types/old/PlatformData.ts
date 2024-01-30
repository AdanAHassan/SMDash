import { platformType } from "../StringLiterals"
import { platformMetric } from "./PlatformMetric"

export type platformData = {
  platform: platformType,
  metrics: platformMetric[]
}
