export interface Specialists {
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
    feedbacks: any[]
}

export interface Specialist {
    id: string
    name: string
    description: string
    doctors: any[]
    isDeleted: boolean
}

export interface ServiceType {
    id: string
    name: string
    isDeleted: boolean
    services: any[]
    doctors: any[]
}
