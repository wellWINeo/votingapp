import { QuestionAnswer } from "./question-answer";
import { QuestionAnswerStatistic } from "./question-answer-statistic";

export type ResultStatistics = ResultStatistic[];

export interface ResultStatistic {
  questionText: string;
  statistics: QuestionAnswerStatistic[],
  answers: QuestionAnswer[],
}
