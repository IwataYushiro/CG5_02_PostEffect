using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBlur : MonoBehaviour
{
    public Shader shader;
    private Material material;
    private void Awake()
    {
        material = new Material(shader);    //�V�F�[�_�[�����蓖�Ă�
    }
    
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //�����_�[�e�N�X�`��
        RenderTexture buf1 = RenderTexture.GetTemporary(source.width / 2, source.height / 2, 0, source.format);
        RenderTexture buf2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0, source.format);
        RenderTexture buf3 = RenderTexture.GetTemporary(source.width / 8, source.height / 8, 0, source.format);
        //�V�F�[�_�[�K���p�o�b�t�@
        RenderTexture blurTex = RenderTexture.GetTemporary(buf3.width, buf3.height, 0, buf3.format);
        
        //�_�E���T���v�����O
        Graphics.Blit(source, buf1);
        Graphics.Blit(buf1, buf2);
        Graphics.Blit(buf2, buf3);
        Graphics.Blit(buf3, blurTex, material);
        //�A�b�v�T���v�����O
        Graphics.Blit(blurTex, buf2);
        Graphics.Blit(buf2, buf1);
        Graphics.Blit(buf1, destination);
        //�m�ۂ����烊���[�X���悤��
        RenderTexture.ReleaseTemporary(buf1);
        RenderTexture.ReleaseTemporary(buf2);
        RenderTexture.ReleaseTemporary(buf3);
        RenderTexture.ReleaseTemporary(blurTex);
    }
}
