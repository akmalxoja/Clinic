export interface ServiceModel {
    id: string
    name: string
    price: number
    description: string
    isDeleted: boolean
    serviceTypeId: string
    feedbacks: any[]
    serviceType: any[]
}