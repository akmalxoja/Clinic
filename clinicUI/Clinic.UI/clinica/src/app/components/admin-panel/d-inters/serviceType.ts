import { Service } from "./service"

export interface ServiceType {
    id: string
    name: string
    isDeleted: boolean
    services: Service[]
    doctors: any[]
  }