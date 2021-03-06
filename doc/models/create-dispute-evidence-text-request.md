
# Create Dispute Evidence Text Request

Defines parameters for a CreateDisputeEvidenceText request.

## Structure

`CreateDisputeEvidenceTextRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdempotencyKey` | `string` |  | Unique ID. For more information,<br>see [Idempotency](https://developer.squareup.com/docs/docs/working-with-apis/idempotency). |
| `EvidenceType` | [`string`](/doc/models/dispute-evidence-type.md) | Optional | Type of the dispute evidence. |
| `EvidenceText` | `string` |  | The evidence string. |

## Example (as JSON)

```json
{
  "evidence_text": "1Z8888888888888888",
  "evidence_type": "TRACKING_NUMBER",
  "idempotency_key": "ed3ee3933d946f1514d505d173c82648"
}
```

