using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;                                                  // Add KoreanTyper namespace | 네임 스페이스 추가

//===================================================================================================================
//  Auto Demo
//  자동으로 글자가 입력되는 데모
//===================================================================================================================
public class Credit : MonoBehaviour {
    public Text[] CreditTexts;

    private void Start() {
        StartCoroutine(TypingText());
    }

    public IEnumerator TypingText() {
        while (true) {
            //=======================================================================================================
            // Initializing | 초기화
            //=======================================================================================================
            string[] strings = new string[6]{ "Credit",
                                              "정현우",
                                              "이준혁","김하늘","김문경","김혜린" };
            foreach (Text t in CreditTexts)
                t.text = "";
            //=======================================================================================================


            //=======================================================================================================
            //  Typing effect | 타이핑 효과
            //=======================================================================================================
            for (int t = 0; t < CreditTexts.Length && t < strings.Length; t++) {
                int strTypingLength = strings[t].GetTypingLength();

                for (int i = 0; i <= strTypingLength; i++) {
                    CreditTexts[t].text = strings[t].Typing(i);
                    yield return new WaitForSeconds(0.03f);
                }
                // Wait 1 second per 1 sentence | 한 문장마다 1초씩 대기
                yield return new WaitForSeconds(1f);
            }
            // Wait 1 second at the end | 마지막에 1초 추가 대기함
            yield return new WaitForSeconds(1f);
        }
    }
}

