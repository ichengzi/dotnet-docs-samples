// Copyright 2017 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
// [START datastore_quickstart]
using Google.Cloud.Datastore.V1;

namespace GoogleCloudSamples
{
    public class QuickStart
    {
        public static void Main(string[] args)
        {
            // Your Google Cloud Platform project ID
            string projectId = "book-196913";

            // Instantiates a client
            DatastoreDb db = DatastoreDb.Create(projectId);

            // The kind for the new entity
            string kind = "book_shengxu";
            // The name/ID for the new entity
            string article_id = "6290265";
            KeyFactory keyFactory = db.CreateKeyFactory(kind);
            // The Cloud Datastore key for the new entity
            Key key = keyFactory.CreateKey(article_id);

            var contenttmp = @"这才多长时间过去，当年那个都不曾被他们注意、没有放在眼中的小土著，竟在短短的一年内从圣者层次突破到神级领域，位列神将之巅，震撼人心。

他们惶恐了，这种进化速度就是在阳间也吓死人，除非古代那几个特殊时期，不然的话怎能出现？

在阴间宇宙中，法则不全，天地残缺，此外还有“天花板”，最高不过映照级，他居然能走到这一步，逆天了吗？

噗！

楚风的剑翼扇动，如同一个十二羽翼的神王，呼啸天地间，再次将一位神祇的头颅斩落，根本就没有人能挡住他。";
            var task = new Entity
            {
                Key = key,
                ["url"] = "https://www.piaotian.com/html/8/8253/6290265.html",
                ["content"] = contenttmp,
                ["create_date"] = DateTimeOffset.Now,
                ["last_upate_date"] = DateTimeOffset.Now,
            };
            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                // Saves the task
                transaction.Upsert(task);
                transaction.Commit();

                Console.WriteLine($"Saved {task.Key.Path[0].Name}: {(string)task["url"]}");
            }
        }
    }
}
// [END datastore_quickstart]