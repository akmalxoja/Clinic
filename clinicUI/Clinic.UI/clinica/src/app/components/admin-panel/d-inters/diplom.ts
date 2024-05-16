import { Doctor } from "./doctor"

export interface Diplom {
    id: string
    litsenzyaId: string
    picturePath: string
    isDeleted: boolean
    doctorId: string
    doctor: Doctor
}
