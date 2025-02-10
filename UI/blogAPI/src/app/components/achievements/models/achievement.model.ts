export interface Achievement{
    id: number;
    name: string;
    conditionType: number;
    conditionValue: number;
    description: string;
    imageUri: string;
    progress: number;
}