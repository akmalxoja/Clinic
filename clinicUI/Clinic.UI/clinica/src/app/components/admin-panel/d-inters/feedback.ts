import { Doctor } from "./doctor";
import { Service } from "./service";
export interface Feedback{
    id:string,
    video:string,
    description:string,
    isDeleted:boolean,
    doctorId:string,
    serviceId:string,
    writedDate:Date,
    doctor:Doctor,
    service:Service,
    user:any[]
}