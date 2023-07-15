using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena que deseja carregar

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator  LoadSceneAsync()
    {
        yield return null; // Aguarda um frame para evitar hiccups
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Isso evita que a cena seja ativada automaticamente após o carregamento
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            // Aqui você pode atualizar a barra de progresso ou fazer qualquer outra coisa para indicar o carregamento

            // Quando o progresso atingir 0.9 (90%), permita a ativação da cena para finalizar o carregamento
            if (asyncLoad.progress >= 0.9f)
                asyncLoad.allowSceneActivation = true;

            yield return null;
        }
    }
}