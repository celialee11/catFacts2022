<h1> Cat facts challenge </h1>
<p> Welcome to cat facts challenge. You can find out over 200 amazing cat facts here. Please read below introduction of APIs. Let's go!</p>
<h2>How to start</h2>
<p> 1. Download the <b><i>Sample/cat-facts-data.json</i></b> file.</p>
<p> 2. Modify a key in <b><i>web.config</i></b> file. Change the value of a key in <i>appSettings</i>.</p>
<div class="snippet-clipboard-content notranslate position-relative overflow-auto">
<pre class="notranslate">
<code> 
&lt;appSettings&gt;
    &lt;add key="DataFilePath" value="Your File Path" /&gt;
</code>
</pre>
</div>
<h2>API-1 : Get Random Fact </h2>
<p>Return a random cat fact on a GET request</p>
<h3>Example path with optional parameters</h3>
<div class="snippet-clipboard-content notranslate position-relative overflow-auto">
<pre class="notranslate">
<code> https://localhost:55555/CatFact/getFacts?max_length=100</code>
</pre>
</div>
<h3>Responses</h3>
<div class="snippet-clipboard-content notranslate position-relative overflow-auto">
<pre class="notranslate">
<code> 
[
  {
    "fact": "string",
    "length": 0
  }
]
</code>
</pre>
</div>
<h2>API-2 : Add new fact </h2>
<p>Add new fact to the cat-facts-data.json file on a POST request</p>
<h3>Example path</h3>
<div class="snippet-clipboard-content notranslate position-relative overflow-auto">
<pre class="notranslate">
<code> https://localhost:55555/CatFact/addNewFact</code>
</pre>
</div>
<h3>Parameters</h3>
<div class="snippet-clipboard-content notranslate position-relative overflow-auto">
<pre class="notranslate">
<code> 
{
    "fact": "xxxxxxxx",
    "length": 8
}
</code>
</pre>
</div>
<h3>Responses</h3>
<div class="snippet-clipboard-content notranslate position-relative overflow-auto">
<pre class="notranslate">
<code> 
[
  {
    "fact": "string",
    "length": 0
  }
]
</code>
</pre>
</div>
<h2>API-3 : Get a list of facts </h2>
<p>Get a list of facts on a GET request</p>
<h3>Example path with optional parameters</h3>
<div class="snippet-clipboard-content notranslate position-relative overflow-auto">
<pre class="notranslate">
<code> https://localhost:55555/CatFact/getFacts?max_length=100&limit=2</code>
</pre>
</div>
<h3>Responses</h3>
<div class="snippet-clipboard-content notranslate position-relative overflow-auto">
<pre class="notranslate">
<code> 
[
  {
    "fact": "string",
    "length": 0
  }
]
</code>
</pre>
</div>


