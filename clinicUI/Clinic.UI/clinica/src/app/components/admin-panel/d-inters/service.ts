import { Feedback } from "./feedback"

export interface Service {
    id: string
    name: string
    price: number
    description: string
    isDeleted: boolean
    serviceTypeId: string
    feedbacks: Feedback[]
    serviceType: any
  }