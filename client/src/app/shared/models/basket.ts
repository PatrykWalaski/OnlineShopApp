export interface IBasket {
    guid: string;
    items: IBasketItem[];
}

export interface IBasketItem {
    productId: number;
    name: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    brand: string;
    type: string;
}


export class Basket implements IBasket {
    guid: string;
    items: IBasketItem[] = [];
}

export interface IBasketTotals {
    shipping: number;
    subtotal: number;
    total: number;
}
