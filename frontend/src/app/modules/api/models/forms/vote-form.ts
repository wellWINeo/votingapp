export interface VoteForm {
  id: string;
  title: string;
  description: string;
  createdAt: Date;
  createdBy: string;
  isCompleted: boolean;
  questions: {
    id: string;
    text: string;
    isMultipleAllowed: boolean;
    isCustomAllowed: boolean;
    options: {
      id: string;
      value: string;
    }[];
  }[];
}
