import { genericCardType } from "./CustomChartTypes"
import { platformType } from "./StringLiterals"

export type CompanyType = {
  id: number,
  name: string,
  platforms: platformType[],
  data: genericCardType[]
}
