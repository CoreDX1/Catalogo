export interface ApiResponse<T> {
  data: T;
  metadata: Metadata;
}

export interface Metadata {
  statusCode: number;
  message: string;
}
