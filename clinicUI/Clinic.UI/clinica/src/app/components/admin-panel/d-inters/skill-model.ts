export interface SkillModel {
    id: string;
    name: string;
    doctors: any[]; // Recursive type to represent nested doctors
    isDeleted: boolean;
}
