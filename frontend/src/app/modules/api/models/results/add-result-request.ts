export interface AddResultRequest {
  formId: string;
  questions: {
    questionId: string;
    values: string[];
  }[];
}
