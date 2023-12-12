using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // Except

/// <summary>
/// �J�����ƑΏۂƂ̊Ԃ̎Օ���(Cover)�𓧖������܂��B
/// �J�����ɕt�����Ă��������B
/// �����ɂ���Օ����� Renderer �R���|�[�l���g��t�����Ă���K�v������܂��B
/// </summary>
public class ObjectTransparency : MonoBehaviour
{
    /// <summary>
    /// ��ʑ̂��w�肵�Ă��������B
    /// </summary>
    [SerializeField]
    private Transform subject_;

    /// <summary>
    /// �Օ����̃��C���[���̃��X�g�B
    /// </summary>
    [SerializeField]
    private List<string> coverLayerNameList_;

    /// <summary>
    /// �Օ����Ƃ��郌�C���[�}�X�N�B
    /// </summary>
    private int layerMask_;

    /// <summary>
    /// ����� Update �Ō��o���ꂽ�Օ����� Renderer �R���|�[�l���g�B
    /// </summary>
    public List<Renderer> rendererHitsList_ = new List<Renderer>();

    /// <summary>
    /// �O��� Update �Ō��o���ꂽ�Օ����� Renderer �R���|�[�l���g�B
    /// ����� Update �ŊY�����Ȃ��ꍇ�́A�Օ����ł͂Ȃ��Ȃ����̂� Renderer �R���|�[�l���g��L���ɂ���B
    /// </summary>
    public Renderer[] rendererHitsPrevs_;


    // Use this for initialization
    void Start()
    {
        // �Օ����̃��C���[�}�X�N���A���C���[���̃��X�g���獇������B
        layerMask_ = 0;
        foreach (string _layerName in coverLayerNameList_)
        {
            layerMask_ |= 1 << LayerMask.NameToLayer(_layerName);
        }

    }


    // Update is called once per frame
    void Update()
    {
        // �J�����Ɣ�ʑ̂����� ray ���쐬
        Vector3 _difference = (subject_.transform.position - this.transform.position);
        Vector3 _direction = _difference.normalized;
        Ray _ray = new Ray(this.transform.position, _direction);

        // �O��̌��ʂ�ޔ����Ă���ARaycast ���č���̎Օ����̃��X�g���擾����
        RaycastHit[] _hits = Physics.RaycastAll(_ray, _difference.magnitude, layerMask_);


        rendererHitsPrevs_ = rendererHitsList_.ToArray();
        rendererHitsList_.Clear();
        // �Օ����͈ꎞ�I�ɂ��ׂĕ`��@�\�𖳌��ɂ���B
        foreach (RaycastHit _hit in _hits)
        {
            // �Օ�������ʑ̂̏ꍇ�͗�O�Ƃ���
            if (_hit.collider.gameObject == subject_)
            {
                continue;
            }

            // �Օ����� Renderer �R���|�[�l���g�𖳌��ɂ���
            Renderer renderer = _hit.collider.gameObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                // �}�e���A�����擾
                Material material = renderer.material;

                // �}�e���A���̐F�����擾���āA�A���t�@�l��ύX
                Color baseColor = material.color;
                baseColor.a = 0f; // �A���t�@�l��0�ɐݒ�

                // �A���t�@�l��ύX����v���p�e�B�� "_BaseColor" �̏ꍇ
                material.SetColor("_BaseColor", baseColor);
            }
        }

        // �O��܂őΏۂŁA����ΏۂłȂ��Ȃ������̂́A�\�������ɖ߂��B
        foreach (Renderer _renderer in rendererHitsPrevs_.Except<Renderer>(rendererHitsList_))
        {
            // �Օ����łȂ��Ȃ��� Renderer �R���|�[�l���g��L���ɂ���
            if (_renderer != null)
            {
                _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 1f);
            }
        }

    }
}