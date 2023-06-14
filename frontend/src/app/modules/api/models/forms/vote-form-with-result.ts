export interface VoteFormWithResult {
  formId: string;
  title: string;
  description: string;
  createdAt: Date;
  createdBy: string;
  isCompleted: boolean;
  isVoted: boolean;
  isEditable: boolean;
  questions: {
    questionId: string;
    text: string;
    isMultipleAllowed: boolean;
    isCustomAllowed: boolean;
    options: {
      id: string;
      value: string;
    }[];
    selectedOptions: {
      id: string;
      value: string;
    }[];
  }[];
}
