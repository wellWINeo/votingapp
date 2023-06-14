export interface CreateVoteFormRequest {
  title: string;
  description: string | null;
  accessMode: number;
  questions: {
    text: string;
    isMultipleAllowed: boolean;
    isCustomAllowed: boolean;
    options: string[];
  }[];
}
