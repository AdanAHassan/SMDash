// Types that will be converted to icons
// Creating arr first to be used elsewhere
export const platformTypeArr = ["twitter", "instagram", "youtube", "facebook", "Loading" ] as const
export const platformIconArr = ["iconoirTwitter", "iconoirInstagram", "iconoirYoutube", "iconoirFacebookTag", null] as const
export type platformType = typeof platformTypeArr[number]
export type platformIcon = typeof platformIconArr[number]

const genericMetricsArr = ["Impressions", "Followers", "Likes", "Replies", "Loading"]
const twitterMetricsArr = ["Quotes", "Retweets"]
export const metricTypeArr = [...genericMetricsArr, ...twitterMetricsArr] as const

const genericIconArr = ["iconoirEyeEmpty", "iconoirHeart", "iconoirMessage", "iconoirAddUser"]
const twitterIconArr = ["customIconQuote", "customIconRetweet"]
export const metricIconArr = [...genericIconArr, ...twitterIconArr] as const

export type metricType = typeof metricTypeArr[number]
export type metricIcon = typeof metricIconArr[number]

export type typeName = platformType | metricType
export type iconType<T> = T extends platformType ? platformIcon : T extends metricType ? metricIcon : never

// Others

