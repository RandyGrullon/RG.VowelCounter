using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Counter.Tests
{
        public class VowelsCounterFacts
    {
        /*
*DONE=> n1. null -> throw ArgumentNullException
*DONE=> p1. "" -> {}
*DONE=> p4. "024821858" -> {}            
*DONE=> p3. "hola@mundo.com" -> { 'a': 1, 'o': 3, 'u': 1 }
DONE=> p2. "INS-368" -> { 'i': 1 } //el contador sera Case Insensitive, y la salida sera minuscula
*=> px. "Murcielago x MURCIELAGO = mUrciElagO cuadrado" -> { 'a': 5, 'e': 3, 'i': 3, 'o': 4, 'u': 4 }
         */

        [Test]
        public void Input_null_return_ArgumentNullException()
            => Assert.That(() => VowelsCounter.Count(null),
                Throws.ArgumentNullException
                    .With.Property(nameof(ArgumentNullException.ParamName)).EqualTo("text"));

        [Test]
        public void Input_Empty_return_empty_Dictionary(){
            IDictionary<char, int> res = VowelsCounter.Count("");
            Assert.That(res, Is.Empty);
        }
        [Test]
        public void Input_Number_return_empty_Dictionary(){
            Assert.IsEmpty(VowelsCounter.Count("024821858"));
        }

        [Test]
        public void Input_Email_return_Vowel_counted(){
        //"hola@mundo.com" -> { 'a': 1, 'o': 3, 'u': 1 }
        var result = new Dictionary<char, int>(){
            {'a', 1},
            {'o', 3},
            {'u', 1}
        };
            var recent = VowelsCounter.Count("hola@mundo.com");
            Assert.AreEqual(result, recent);
            
        }

        [Test]
        public void Input_insensitiveCase_return_toLowerCase(){
        // "INS-368" -> { 'i': 1 }
        var result = new Dictionary<char, int>(){
            {'i', 1}
            
        };
            var recent = VowelsCounter.Count("INS-368");
            Assert.AreEqual(result, recent);
        }

        [Test]
        public void Input_text_Lower_and_Upper_case_return_Dictionary_vowels_counted(){
//"Murcielago x MURCIELAGO = mUrciElagO cuadrado" -> { 'a': 5, 'e': 3, 'i': 3, 'o': 4, 'u': 4 }
        var result = new Dictionary<char, int>(){
            {'a', 5},
            {'e', 3},
            {'i', 3},
            {'o', 4},
            {'u', 4}
        };
            var recent = VowelsCounter.Count("Murcielago x MURCIELAGO = mUrciElagO cuadrado");
            Assert.AreEqual(result, recent);
            
        }
    }
}