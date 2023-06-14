import { VoteValue } from "./vote-value";

export interface VoteResult {
  id: string,
  createdBy: string,
  values: VoteValue[],
}
