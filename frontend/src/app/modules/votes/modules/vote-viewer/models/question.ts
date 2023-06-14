import { Option } from './option';

export interface Question {
  questionId: string,
  text: string,
  options: Option[]
}
