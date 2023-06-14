import { Question } from './question';

export interface Vote {
  title: string;
  description: string | null;
  questions: Question[];
}
