using UnityEngine;

public class TrailEffectSpawner : MonoBehaviour
{
    public GameObject trailEffectPrefab; // �g���C���G�t�F�N�g�̃v���n�u

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �X�y�[�X�L�[�������ꂽ�Ƃ��Ƀg���C���G�t�F�N�g���C���X�^���X������
            InstantiateTrailEffect();
        }
    }

    private void InstantiateTrailEffect()
    {
        if (trailEffectPrefab != null)
        {
            // �g���C���G�t�F�N�g�̃C���X�^���X�𐶐�
            GameObject trailEffectInstance = Instantiate(trailEffectPrefab, transform.position, Quaternion.identity);

            // ���������G�t�F�N�g����莞�Ԍ�ɒ�~������
            TrailRenderer[] trailRenderers = trailEffectInstance.GetComponentsInChildren<TrailRenderer>();
            foreach (TrailRenderer trailRenderer in trailRenderers)
            {
                trailRenderer.emitting = true; // �g���C�����Đ�
                trailRenderer.gameObject.SetActive(true); // GameObject���A�N�e�B�u�ɂ���
                StartCoroutine(StopTrailAfterDelay(trailRenderer, 2.0f)); // 2�b��ɍĐ����~
            }
        }
    }

    private System.Collections.IEnumerator StopTrailAfterDelay(TrailRenderer trailRenderer, float delay)
    {
        yield return new WaitForSeconds(delay);
        trailRenderer.emitting = false; // �g���C���̍Đ����~
        trailRenderer.gameObject.SetActive(false); // GameObject���A�N�e�B�u�ɂ���
    }
}