export interface Compaigns {
    category: string;
    code: string;
    description: string;
    isDefaultCampaign: boolean;
    isPrivateCampaign: boolean;
    isStandardCampaign: boolean;
    links: Array<any>[];
    name: string;
    promocodes: Array<string>[];
}

export interface PromoCodeProducts {
    products: Products[];
    promoCode: string;
    promoCodeDescription: string;
    promoCodeTagLine: string;
}

export interface Products{
    accessLimit: number;
    accessLimitUnits: string;
    category: string;
    friendlyName: string;
    heroImage: string;
    heroTagLine: string;
    highlight1: string;
    highlight1Icon: string;
    highlight2: string;
    highlight2Icon: string;
    highlight3: string;
    highlight3Icon: string;
    highlights: Array<string>;
    includes: Array<any>;
    isHero: boolean;
    lineSpeed: number;
    onceOffCharge: boolean;
    parameters: Parameters[];
    productCode: string;
    productDescription: string;
    productDiscountAmount: number;
    productDiscountPeriod: number;
    productDiscountSequence: number;
    productDiscountType: string;
    productName: string;
    productRate: number;
    sellOnline: boolean
    seoDescription: string;
    seoKeywords: Array<any>;
    seoTitle: string;
    subcategory: string;
    summary: string;
    technicalTerms: string;
}

export interface Parameters{
    name: string;
    value: string;
}

export interface SummarizedProduct{
    productCode: string;
    productName: string;
    productRate: number;
    provider: string;
}