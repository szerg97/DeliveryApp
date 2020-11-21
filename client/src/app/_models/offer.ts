export interface Offer{
    offerId: string;
    registered: Date;
    text: string;
    creatorId: string;
    creatorName: string;
    companyName: string;
    solution: string;
    fromCity: number;
    fromZip: number;
    fromCountry: number;
    toCity: number;
    toZip: number;
    toCountry: number;
}