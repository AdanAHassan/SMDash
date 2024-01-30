import { Injectable } from '@angular/core';
import { genericCardType } from 'src/app/shared/types/CustomChartTypes';
import { iconType, typeName } from 'src/app/shared/types/StringLiterals';

@Injectable({
  providedIn: 'root'
})
export class HelperService {

  public capitalizeFirstLetter(str: string): string {
    return str[0].toUpperCase() + str.substring(1)
  }

  public splitString(str: string): string {
    return str.replace(/([A-Z][a-z])/g, ' $1').trim()
  }

  public convertToIcon<T extends typeName>(inputString: T): iconType<T>   {
    switch (inputString.toLowerCase()) {
      // appType param, return appIcon
      case 'twitter':
        return 'iconoirTwitter' as iconType<T>
      case 'instagram':
        return 'iconoirInstagram' as iconType<T>
      case 'youtube':
        return 'iconoirYoutube' as iconType<T>
      case 'facebook':
        return 'iconoirFacebookTag' as iconType<T>
      // metricType param, return metricIcon
      // generic
      case 'impressions':
        return 'iconoirEyeEmpty' as iconType<T>
      case 'followers':
        return 'iconoirAddUser' as iconType<T>
      case 'likes':
        return 'iconoirHeart' as iconType<T>
      case 'replies':
        return 'iconoirMessage' as iconType<T>
      // twitter specific
      case 'quotes':
        return 'customIconQuote' as iconType<T>
      case 'retweets':
        return 'customIconRetweet' as iconType<T>
      default:
        console.log(`Error:\tIcon string conversion for ${inputString} failed`)
        return null  as iconType<T>
    }
  }
}
