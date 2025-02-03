import { Order } from "./Order"

export interface Account{
    role: string
    orders: Order[]
}