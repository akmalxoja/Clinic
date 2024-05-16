import { Feedback } from "./feedback"
import { ServiceType } from "./serviceType"
import { Specialist } from "./speclist"

export interface Doctor {
    id: string
    name: string
    address: string
    startWork: number
    tUsername: string
    isDeleted: boolean
    picturePath: string
    specialistId: string
    serviceTypeId: string
    specialist: Specialist
    serviceType: ServiceType
    results: any[]
    educations: any[]
    diploms: any[]
    skills: any[]
    feedbacks: Feedback[]
  }